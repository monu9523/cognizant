import React, { Component } from "react";

class CurrencyConvertor extends Component {

    constructor(props) {
        super(props);

        this.state = {
            amount: "",
            currency: "Euro"
        };
    }

    handleChange = (event) => {
        this.setState({
            amount: event.target.value
        });
    };

    handleSubmit = (event) => {
        event.preventDefault();

        const amount = Number(this.state.amount);

        // 1 Euro = 80 Rupees
        const rupees = amount * 80;

        alert("Converting to Euro Amount is " + rupees);
    };

    render() {
        return (
            <div>

                <h1 style={{ color: "green" }}>
                    Currency Convertor!!!
                </h1>

                <form onSubmit={this.handleSubmit}>

                    <label>Amount:&nbsp;&nbsp;</label>

                    <input
                        type="number"
                        value={this.state.amount}
                        onChange={this.handleChange}
                    />

                    <br /><br />

                    <label>Currency:&nbsp;&nbsp;</label>

                    <select
                        value={this.state.currency}
                        onChange={(e) =>
                            this.setState({ currency: e.target.value })
                        }
                    >
                        <option>Euro</option>
                    </select>

                    <br /><br />

                    <button type="submit">
                        Submit
                    </button>

                </form>

            </div>
        );
    }
}

export default CurrencyConvertor;