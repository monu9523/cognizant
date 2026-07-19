import React from "react";

export default function ListOfIndianPlayers({ IndianPlayers }) {

    return (
        <div>
            {IndianPlayers.map((player, index) => (
                <p key={index}>{player}</p>
            ))}
        </div>
    );
}