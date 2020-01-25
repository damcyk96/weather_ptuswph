import React from "react";
const api = {
  key: "2cedf13fcae3c8e374427e597af727f0",
  base: "https://api.openweathermap.org/data/2.5"
};
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
function App() {
  return (
    <div className="app">
      <main>
        <div className="search-box">
          <input type="text" className="search-bar" placeholder="Szukaj..." />
        </div>
        <div>
          <div className="location-box">
            <div className="location">New York City, US</div>
            <div className="date">{dateBuilder(new Date())}</div>
          </div>
          <div className="weather-box">
            <div className="temp">15</div>
            <div className="weather">Sunny</div>
          </div>
        </div>
      </main>
    </div>
  );
}

export default App;
