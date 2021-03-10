import React, { Component } from 'react';
import './FetchData.css';
import StarRatingComponent from 'react-star-rating-component';
import Popover from 'react-bootstrap/Popover';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Button from 'react-bootstrap/Button';


const popover = (
    <Popover id="popover-basic">
        <Popover.Title as="h3">Merci donner une note</Popover.Title>
        <Popover.Content>
            <StarRatingComponent
                name="rate2"
                starCount={5}
            />
    </Popover.Content>
    </Popover>
);

export class Location extends Component {

    constructor(props) {
        super(props);
        this.state = { newOpinion: '', locationOpinions: this.props.element.opinionList, rateValue: 2.5, hover: -1 };

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

            let temp = this.state.locationOpinions;
            temp.push(op);
            this.setState({ locationOpinions: temp });
            this.setState({ newOpinion: '' });
        }

        let tooltip = document.querySelector('#sumbit');
       
     
    }

    render() {
        return (
            <div className="locationDetails">
                <img src={this.props.element.linkPicture} alt="Location s image" />
                <h1>{this.props.element.name}</h1>


                <div className="rating">
              
                  
                </div>

                <h2>Avis : </h2>

                <div className="Opinions">
                    {this.state.locationOpinions.map((opinion, index) =>
                            <div key={"opn" + index} className="opinion">
                                <div id="opAvis">{opinion.content}</div>
                                <StarRatingComponent
                                    name="rate1"
                                    starCount={5}
                                    editing={false}
                                    value={opinion.rateOpinion}
                                />
                            </div>
                            )}
                </div>
                <div className="inputOp">

                    <input type='text' placeholder='Rédiger votre Avis' className="form-control" value={this.state.newOpinion} onChange={this.handleChange} />
                    <OverlayTrigger trigger="click" placement="top" overlay={popover}>
                        <Button variant="success">Poster Avis</Button>
                    </OverlayTrigger>

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