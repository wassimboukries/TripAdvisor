import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

    componentDidMount() {
        this.populateLocationData();
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
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.id}>
                <td>{forecast.id}</td>
                <td><img src={forecast.linkPicture} width='100px' alt="loading img" /></td>
                <td>{forecast.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }

    async populateLocationData() {
        const response = await fetch('location');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }

    async populateOpinionData() {
        const response = await fetch('opinion');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
