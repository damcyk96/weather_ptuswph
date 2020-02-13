import React, { useState } from "react";
import Unsplash from "unsplash-js";

const api = {
  key: "2cedf13fcae3c8e374427e597af727f0",
  base: "https://api.openweathermap.org/data/2.5/"
};

const unsplash = new Unsplash({
  accessKey: "0b305e533471e596c2669d024fd79675086d9aa45b76d8ea037bfbbd22165027",
  secret: "0221ffda26394dff558232bcf2f24e967a24a2ed18e9ebc808b20fb90a0ac43f",
  base: `https://api.unsplash.com/search/photos?client_id=0b305e533471e596c2669d024fd79675086d9aa45b76d8ea037bfbbd22165027&`
});

function App() {
  const [query, setQuery] = useState("");
  const [weather, setWeather] = useState({});

  const search = evt => {
    if (evt.key === "Enter") {
      fetch(`${api.base}weather?q=${query}&units=metric&APPID=${api.key}`)
        .then(res => res.json())
        .then(result => {
          setWeather(result);
          setQuery("");
          console.log(result);
        });
    }
  };

  const [city, setCity] = useState({});
  const [bg, setBg] = useState({});
  const background = x => {
    if (x.key === "Enter") {
      fetch(
        `https://api.unsplash.com/search/photos?client_id=0b305e533471e596c2669d024fd79675086d9aa45b76d8ea037bfbbd22165027&query=${query}&per_page=1`
      ) /* Temporary string */
        .then(res => res.json())
        .then(result => {
          setCity(result);
          setQuery("");
          console.log(result);
          setBg(result.results[0].urls.regular);
        });
    }
  };

  // bg = city.results[0].urls.full;

  const dateBuilder = d => {
    let months = [
      "Styczeń",
      "Luty",
      "Marzec",
      "Kwiecień",
      "Maj",
      "Czerwiec",
      "Lipiec",
      "Sierpień",
      "Wrzesień",
      "Październik",
      "Listopad",
      "Grudzień"
    ];
    let days = [
      "Poniedziałek",
      "Wtorek",
      "Środa",
      "Czwartek",
      "Piątek",
      "Sobota",
      "Niedziela"
    ];

    let day = days[d.getDay()];
    let date = d.getDate();
    let month = months[d.getMonth()];
    let year = d.getFullYear();

    return `${day} ${date} ${month} ${year}`;
  };
  return (
    <div
      className="main-bg"
      style={{
        backgroundImage: `url(${bg})`
      }}
    >
      <main>
        <div className="search-box">
          <input
            type="text"
            className="search-bar"
            placeholder="Szukaj..."
            onChange={e => setQuery(e.target.value)}
            value={query}
            onKeyPress={e => {
              search(e);
              background(e);
            }}
          />
        </div>
        {typeof weather.main != "undefined" ? (
          <div>
            <div className="location-box">
              <div className="location">
                {weather.name}, {weather.sys.country}
              </div>
              <div className="date">{dateBuilder(new Date())}</div>
            </div>
            <div className="weather-box">
              <div className="temp">{Math.round(weather.main.temp)}°C</div>
              <div className="weather">{weather.weather[0].description}</div>
              <div className="description">{city.results[0].description}</div>
            </div>
          </div>
        ) : (
          ""
        )}
      </main>
    </div>
  );
}

export default App;
