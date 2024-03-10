import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [pokemons, setpokemon] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const contents = pokemons === undefined
        ? <p><em>Error Loading API call</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {pokemons.map(pokemon =>
                    <tr key={pokemon.Number}>
                        <td>{pokemon.Name}</td>
                        <td>{pokemon.Number}</td>
                        <td>{pokemon.Type1}</td>              
                        <td>{pokemon.Type2}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Pokemon Moveset Guesser</h1>
            <p>This page will load a random Pokemon please refresh the page.</p>
            {contents}
        </div>
    );
    
    async function populateWeatherData() {
        const response = await fetch('GetPokemon');
        const data = await response.json();
        setpokemon(data);
    }
}

export default App;