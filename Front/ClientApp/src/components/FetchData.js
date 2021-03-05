import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    

  constructor(props) {
    super(props);
      this.state = { forecasts: [], forecastOpinion: [], loading: true };
  }

    componentDidMount() {
        this.populateLocationData();
        this.populateOpinionData();
  }

    static renderForecastsTable(forecasts) {
     
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">

                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Image</th>
                        <th>Name</th>
                    </tr>
                </thead>
                {forecasts.map(forecast =>
                    <tbody key={forecast.id}>

                        <tr  >
                            <td> {forecast.id} </td>
                            <td><img src={forecast.linkPicture} width='100px' alt="loading img" /></td>
                            <td>{forecast.name}</td>

                        </tr>
                        {forecast.opinionList.map(opinion =>
                            <tr className={"opn-" + forecast.id} >
                                <td>{opinion.id}</td>
                                <td>{opinion.content}</td>
                                <td>{opinion.clientID}</td>
                            </tr>)}
                        
                    </tbody>
                )}
            </table>
        );
    }

  render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Locations: </h1>
        {contents}
      </div>
    );
  }

    async populateLocationData() {
        const response = await fetch('location');
        const data = await response.json();
        data.map(elt => {
            
            fetch('location/getOpinions/' + elt.id, {
                method: 'get'
            })
                .then(json => {
                    debugger;
                    elt.opinionList = json
                });
        });
        this.setState({ forecasts: data, loading: false });
        
    }

    async populateOpinionData() {
        const response = await fetch('opinion');
        const data = await response.json();
        this.setState({ forecastOpinion: data, loading: false });
    }
}
