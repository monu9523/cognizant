import React from "react";
import ListofPlayers from "./Components/ListofPlayers";

import OddPlayers from "./Components/OddPlayers";
import EvenPlayers from "./Components/EvenPlayers";
import ListOfIndianPlayers from "./Components/ListOfIndianPlayers";
import IndianPlayers from "./Components/IndianPlayers";

function App() {

    const players = [
        { name: "Virat Kohli", score: 95 },
        { name: "Rohit Sharma", score: 85 },
        { name: "Shubman Gill", score: 60 },
        { name: "KL Rahul", score: 78 },
        { name: "Hardik Pandya", score: 68 },
        { name: "Ravindra Jadeja", score: 88 },
        { name: "R Ashwin", score: 65 },
        { name: "Jasprit Bumrah", score: 72 },
        { name: "Mohammed Shami", score: 55 },
        { name: "Mohammed Siraj", score: 74 },
        { name: "Surya Kumar Yadav", score: 91 }
    ];

    const IndianTeam = [
        "Virat",
        "Rohit",
        "Gill",
        "Rahul",
        "Hardik",
        "Jadeja"
    ];

    const flag = true;

    if (flag) {
        return (
            <div>
                
                <ListofPlayers players={players} />

                <hr />

                
            </div>
        );
    } else {
        return (
            <div>
                <h1>Indian Team</h1>

                <h2>Odd Players</h2>
                <OddPlayers IndianTeam={IndianTeam} />

                <hr />

                <h2>Even Players</h2>
                <EvenPlayers IndianTeam={IndianTeam} />

                <hr />

                <h1>List of Indian Players Merged</h1>
                <ListOfIndianPlayers IndianPlayers={IndianPlayers} />
            </div>
        );
    }
}

export default App;