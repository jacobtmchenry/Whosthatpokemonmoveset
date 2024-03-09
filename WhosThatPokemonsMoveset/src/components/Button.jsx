export default function GenerateNextPokemon() {
    return (
        <button
            text = "Generate Next Pokemon"
            onClick={GeneratePokemon()}
        ></button>
    );

    function GeneratePokemon()
    {
        console.log("Pokemon Generated")
    }
  }