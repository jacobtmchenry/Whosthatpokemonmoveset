import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [pokemon, setpokemon] = useState();

    console.log(pokemon);

    useEffect(() => {
        populatePokemonData();
    }, []);

    const contents = pokemon === undefined
        ? <p><em>Error Loading API call</em></p>
        :
        <div>
            <div>{pokemon.name}</div>
            <div>{pokemon.number}</div>
            <div>{pokemon.type1}</div> 
            <div>{pokemon.type2}</div>
        </div>

    return (
        <div>
            <h1 id="tabelLabel">Pokemon Moveset Guesser</h1>
            <p>This page will load a random Pokemon please refresh the page.</p>
            {contents}
        </div>
    );
    
    async function populatePokemonData() {
        const response = await fetch('https://localhost:32768/Pokemon')
        const data = await response.json();
        setpokemon(data);

        const
    }
}

export default App;