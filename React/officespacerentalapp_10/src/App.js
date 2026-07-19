import React from "react";
import officeImage from "./office.jpg";
import "./App.css";

function App() {

    const element = "Office Space";

    const jsxatt = (
        <img
            src={officeImage}
            width="25%"
            height="25%"
            alt="Office Space"
        />
    );

    const ItemName = {
        Name: "DBS",
        Rent: 500000,
        Address: "Chennai"
    };

    let colors = [];

    if (ItemName.Rent <= 600000) {
        colors.push("textRed");
    } else {
        colors.push("textGreen");
    }

    return (
        <div>

            <h1>{element}, at Affordable Range</h1>

            {jsxatt}

            <h1>Name: {ItemName.Name}</h1>

            <h3 className={colors.join(" ")}>
                Rent: Rs. {ItemName.Rent}
            </h3>

            <h3>Address: {ItemName.Address}</h3>

        </div>
    );
}

export default App;