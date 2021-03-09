import React, { Component } from 'react';
import './FetchData.css';

export class Location extends Component {

    handleSubmit(event) {
        console.log(event.target.value);
    }

    render() {
        return (
            <div className="locationDetails">
                <img src={this.props.element.linkPicture} alt="Location s image" />
                <h1>{this.props.element.name}</h1>

                <h2>Avis : </h2>
                {
                    this.props.element.opinionList.map(opinion =>
                        <div key={"opn-" + opinion.id} className="opinion">
                            <div>{opinion.clientID} : {opinion.content}</div>
                        </div>
                    )
                }
                <form >
                    <input type='text' placeholder='Rédiger votre Avis' className="form-control" />
                    <button type="submit" ></button>
                </form>
            </div>
            
            );
    }

}