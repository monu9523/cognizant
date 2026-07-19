import React from "react";

function ListofPlayers() {

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

    return (
        <div>
            <h2>List of Players</h2>

            {players.map((player, index) => (
                <p key={index}>
                    {player.name} - {player.score}
                </p>
            ))}

            <h2>Players with Score Below 70</h2>

            {players
                .filter(player => player.score < 70)
                .map((player, index) => (
                    <p key={index}>
                        {player.name} - {player.score}
                    </p>
                ))}
        </div>
    );
}

export default ListofPlayers;