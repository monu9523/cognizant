import "../Stylesheets/mystyle.css";

function CalculateScore(props) {

    
    const score = props.Total / props.goal;
    return (
        <div>
            <h1>Student Details:</h1>

            <p className="name">
                Name: <span>{props.Name}</span>
            </p>

            <p className="school">
                School: <span>{props.School}</span>
            </p>

            <p className="total">
                Total: <span>{props.Total} Marks</span>
            </p>

            <p className="score">
                Score: <span>{score}%</span>
            </p>
        </div>
    );
}

export default CalculateScore;