import React, { Component } from 'react';
import './FetchData.css';
export class Location extends Component {

    

    constructor(props) {
        super(props);
        this.state = { newOpinion: '', forecastOpinions: this.props.element.opinionList, rateValue: 2.5, hover: -1 };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);


    }

    handleChange(event) {
        this.setState({ newOpinion: event.target.value });
    }

    async handleSubmit(event, id) {
        if (this.state.newOpinion !== '') {

            let op = {
                "id": 0,
                "content": this.state.newOpinion,
                "rateOpinion": this.state.rateValue
            };

            await fetch('opinion/' + id,
                {
                    method: 'POST',
                    headers: {
                        'Accept': '/',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(op)
                });

            let temp = this.state.forecastOpinions;
            temp.push(op);
            this.setState({ forecastOpinions: temp });
            this.setState({ newOpinion: '' });
        }
    }

    render() {
        return (
            <div className="locationDetails">
                <img src={this.props.element.linkPicture} alt="Location s image" />
                <h1>{this.props.element.name}</h1>

                <div className="rating">
              
                  
                </div>

                <h2>Avis : </h2>

                {
                            this.state.forecastOpinions.map((opinion, index) =>
                                <div key={"opn" + index} className="opinion">
                                    <div id="opAvis">{opinion.content}</div>
                                    <div id="opRanking">{opinion.rateOpinion} / 5</div>
                                </div>
                            )
                        }

                <div className="inputOp">

                    <input type='text' placeholder='Rédiger votre Avis' className="form-control" value={this.state.newOpinion} onChange={this.handleChange} />
                    <button type="button" className='btn btn-primary' onClick={event => this.handleSubmit(event, this.props.element.id)} >Poster Avis</button>

                </div>
            </div>
            );
    }
}

/*<table className="table table-striped">
                    <thead></thead>
                    <tbody>
                        
                    </tbody>
                </table>*/