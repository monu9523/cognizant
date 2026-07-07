using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        private readonly ProducerConfig producerConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        private IProducer<Null, string> producer;
        private CancellationTokenSource? consumerCts;
        private Task? consumerTask;
        private IConsumer<Ignore, string>? consumer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            producer = new ProducerBuilder<Null, string>(producerConfig).Build();
            consumerCts = new CancellationTokenSource();
            consumerTask = StartConsumer(consumerCts.Token);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            try
            {
                await producer.ProduceAsync("chat-topic",
                    new Message<Null, string>
                    {
                        Value = textBox1.Text
                    });

                richTextBox1.AppendText("Me: " + textBox1.Text + Environment.NewLine);

                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Task StartConsumer(CancellationToken token)
        {
            return Task.Run(() =>
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = "localhost:9092",
                    GroupId = Guid.NewGuid().ToString(),
                    AutoOffsetReset = AutoOffsetReset.Latest,
                    EnableAutoCommit = true
                };

                consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

                consumer.Subscribe("chat-topic");

                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        try
                        {
                            // Use the cancellation-aware Consume overload
                            var result = consumer.Consume(token);

                            if (result?.Message != null)
                            {
                                Invoke(() =>
                                {
                                    richTextBox1.AppendText("Friend: " +
                                        result.Message.Value +
                                        Environment.NewLine);
                                });
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Cancellation requested, break loop
                            break;
                        }
                        catch (ConsumeException cex)
                        {
                            // surface consume errors to UI
                            Invoke(() => richTextBox1.AppendText("Consumer error: " + cex.Error.Reason + Environment.NewLine));
                        }
                        catch (Exception ex)
                        {
                            Invoke(() => richTextBox1.AppendText("Consumer exception: " + ex.Message + Environment.NewLine));
                        }
                    }
                }
                finally
                {
                    try
                    {
                        consumer?.Close();
                    }
                    catch { }

                    try
                    {
                        consumer?.Dispose();
                    }
                    catch { }
                }
            }, token);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Stop consumer
                consumerCts?.Cancel();
                try
                {
                    consumerTask?.Wait(2000);
                }
                catch { }

                producer?.Flush(TimeSpan.FromSeconds(5));
            }
            catch { }
            finally
            {
                producer?.Dispose();
                consumerCts?.Dispose();
            }
        }
    }
}
