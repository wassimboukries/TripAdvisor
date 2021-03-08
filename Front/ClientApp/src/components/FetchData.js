import React, { Component } from 'react';
import './FetchData.css';

export class FetchData extends Component {
    static displayName = FetchData.name;


     
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, weather: []};
    }

    componentDidMount() {
        this.populateLocationData();
        this.populateOpinionData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <div className="corps" >
                {forecasts.map(forecast =>
                    <div key={forecast.id} >

                        <div className="card"  >
                            <h1> {forecast.name} </h1>
                            <div><img src={forecast.linkPicture} alt="loading img" /></div>
                            <div>{forecast.weather.main.temp}&#8451;</div>
                        </div>

                        {forecast.opinionList.map(opinion =>
                            <div className={"opn-" + forecast.id}>
                                <div>{opinion.content}</div>
                                <div>{opinion.clientID}</div>
                            </div>)}
                        
                        
                    </div>
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            :  FetchData.renderForecastsTable(this.state.forecasts);
            


        return (
            <div>
                <h1 id="tabelLabel" >Welcome to TripAdvisor !</h1>
                {contents}
            </div>
        );
    }

    async populateLocationData() {
        const response = await fetch('location');
        const data = await response.json();
        const promises = [];
        data.map(elt => {
            let url = 'https://api.openweathermap.org/data/2.5/weather?q=' + elt.name + ',mar&appid=c21a75b667d6f7abb81f118dcf8d4611&units=metric';
            promises.push(fetch(url)
                .then(res => res.json())
                .then(dataw => elt.weather = dataw));
        });
        const result = await Promise.all(promises);
        this.setState({ forecasts: data, loading: false });
        console.log('forecast', this.state.forecasts);

    }

    async populateOpinionData() {
        const response = await fetch('opinion');
        const data = await response.json();
        this.setState({ forecastOpinion: data, loading: false });
    }

    
}
