import React from "react";

function GuestGreeting() {
    return (
        <div>

            <h2>Welcome Guest</h2>

            <h3>Flight Details</h3>

            <table border="1" cellPadding="8">
                <thead>
                    <tr>
                        <th>Flight</th>
                        <th>Source</th>
                        <th>Destination</th>
                    </tr>
                </thead>

                <tbody>
                    <tr>
                        <td>AI101</td>
                        <td>Delhi</td>
                        <td>Mumbai</td>
                    </tr>

                    <tr>
                        <td>AI202</td>
                        <td>Chennai</td>
                        <td>Bangalore</td>
                    </tr>
                </tbody>
            </table>

            <p>Please login to book tickets.</p>

        </div>
    );
}

export default GuestGreeting;