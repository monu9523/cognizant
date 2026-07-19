import React from "react";

export default function EvenPlayers({ IndianTeam }) {

    const [first, second, third, fourth, fifth, sixth] = IndianTeam;

    return (
        <div>
            <li>Second : {second}</li>
            <li>Fourth : {fourth}</li>
            <li>Sixth : {sixth}</li>
        </div>
    );
}