export default function Pokemon({ pokemon }) {

        return (
            <div>
                <div className="PokemonNameTitle">
                    {pokemon.name}
                </div>
                <div className="PokemonMovesBox">
                    <ul>
                        {pokemon.moves.map((move, index) => (
                            <button className="PokemonMove" key={index}>{move}</button>
                        ))}
                    </ul>
                </div>
                <div>
                    <input
                        id="PokemonAnswerText"
                        type="text"
                    />

                    <button>
                        <button id="PokemonSubmitName" className="Button">Guess!?</button>
                    </button>
                </div>
            </div>
        )
    };