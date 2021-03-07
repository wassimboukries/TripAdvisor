import React, { Component } from 'react';
import './FetchData.css';

export class FetchData extends Component {
    static displayName = FetchData.name;

     
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, weather: [], clickeds: [] };
        this.displayOpinions = this.displayOpinions.bind(this);
    }

    componentDidMount() {
        this.populateLocationData();
        this.populateOpinionData();
    }

     renderForecastsTable(forecasts, clickeds) {
        return (
            <div className="corps" >
                {forecasts.map((forecast, index) =>
                    <div key={forecast.id} >

                        <div className="card"  >
                            <h1 className="card-title"> {forecast.name} </h1>
                            <div><img src={forecast.linkPicture} alt="loading img" /></div>
                            <div>{forecast.weather.main.temp}&#8451;</div>
                            <div><button id={'avis-' + forecast.name} className="btn btn-primary btnAvis" onClick={() => this.displayOpinions(index)}>Avis</button></div>
                            {
                                (clickeds[index])?
                                    <div>
                                        <input type='text' placeholder='Taper votre commentaire' />
                                        {forecast.opinionList.map(opinion =>
                                            <div key={"opn-" + opinion.id} className="opinion">
                                                <div>{opinion.clientID} : {opinion.content}</div>
                                            </div>)}
                                </div> : null
                            }
                            
                        </div>

                        
                        
                        
                    </div>
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForecastsTable(this.state.forecasts, this.state.clickeds);
            


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

        let temp = []
        for (let i = 0; i < this.state.forecasts.length; ++i)
            temp.push(false);

        this.setState({ clickeds: temp });
    }

    async populateOpinionData() {
        const response = await fetch('opinion');
        const data = await response.json();
        this.setState({ forecastOpinion: data, loading: false });
    }

    displayOpinions(index) {
        console.log("ypppppppppppp");
        let temp = this.state.clickeds;
        temp[index] = !temp[index];
        this.setState({ clickeds : temp });
    }
}