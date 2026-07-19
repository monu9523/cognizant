import React from "react";

export default function OddPlayers({ IndianTeam }) {

    const [first, second, third, fourth, fifth, sixth] = IndianTeam;

    return (
        <div>
            <li>First : {first}</li>
            <li>Third : {third}</li>
            <li>Fifth : {fifth}</li>
        </div>
    );
}