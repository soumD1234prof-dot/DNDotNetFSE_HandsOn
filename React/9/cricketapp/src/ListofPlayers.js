export function ListofPlayers(props) {
    const players = props.players;
    return (
        <ul>
            {players.map((item) => {
                return (
                    <li key={item.name}>Mr. {item.name} <span>{item.score}</span></li>
                )
            })}
        </ul>
    )
}

export default ListofPlayers;