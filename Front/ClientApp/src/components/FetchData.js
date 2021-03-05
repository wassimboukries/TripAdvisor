import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;



    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, weather: []};
    }

    componentDidMount() {
        this.populateLocationData();
        this.populateOpinionData();
        
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">

                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Température</th>
                    </tr>
                </thead>
                {forecasts.map(forecast =>
                    <tbody key={forecast.id}>

                        <tr  >
                            <td> {forecast.id} </td>
                            <td><img src={forecast.linkPicture} width='100px' alt="loading img" /></td>
                            <td>{forecast.name}</td>
                            <td>{forecast.weather.main.temp}</td>


                        </tr>
                        
                        {forecast.opinionList.map(opinion => <tr className={"opn-" + forecast.id}  > <td>{opinion.id}</td>
                            <td>{opinion.content}</td>
                            <td>{opinion.clientID}</td></tr>)}
                        
                        
                    </tbody>



                )}
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            :  FetchData.renderForecastsTable(this.state.forecasts);
            


        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
           
        
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