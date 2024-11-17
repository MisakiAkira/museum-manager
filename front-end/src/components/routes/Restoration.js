import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Single.css';

const Restoration = () => {
    const {restorerId, paintingId} = useParams();
    const [restoration, setRestoration] = useState([]);
    const [co, setCost] = useState([]);
    const [sDate, setStartDate] = useState([]);
    const [eDate, setEndDate] = useState([]);
    const url = 'http://localhost:5214/api/restoration/';
    
    useEffect(() => {
        fetch(`${url}${restorerId}&${paintingId}`, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setRestoration(data));
    });

    const handleDelete = async () => {
        await fetch(`${url}${restorerId}&${paintingId}`, {method: 'DELETE', headers: {'Content-Type': 'application/json'}});
        window.location.href = "/restorations"
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        const restorerId = restoration.restorerId;
        const paintingId = restoration.paintingId;
        let cost = Number(restoration.cost);
        let startDate = restoration.startDate;
        let endDate = restoration.endDate;
        if(co.length !== 0){
            cost = Number(co);
        }
        if(sDate.length !== 0){
            startDate = sDate;
        }
        if(eDate.length !== 0){
            endDate = eDate;
        }
        const updateRestorer = {
            restorerId,
            paintingId,
            cost,
            startDate,
            endDate
        }
        console.log(updateRestorer)
        await fetch(url, {method: 'PUT', headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(updateRestorer)});
        setCost('');
        setStartDate('');
        setEndDate('');
    }

    return (
        <div class='container'>
            <a href={`/restorer/${restoration.restorerId}`}>Restorer ID: {restoration.restorerId}</a><br/>
            <a href={`/painting/${restoration.paintingId}`}>Painting ID:{restoration.paintingId}</a><br/>
            Cost: {restoration.cost}<br/>
            Start date: {restoration.startDate}<br/>
            End date: {restoration.endDate}<br/><br/>
            <button class='delete-button' onClick={handleDelete}>Delete</button><br/>
            <form onSubmit={handleUpdate}>
                <label for="cost">Cost:</label>
                <input type="number" id='cost' name='cost' value={co} onChange={(e) => setCost(e.target.value)}/><br/>
                <label for='sdate'>Start date:</label>
                <input type="date" id='sdate' name='sdate' value={sDate} onChange={(e) => setStartDate(e.target.value)}/><br/>
                <label for='edate'>End date:</label>
                <input type="date" id='edate' name='edate' value={eDate} onChange={(e) => setEndDate(e.target.value)}/><br/>
                <button type="submit">Update</button><br/>
            </form>
        </div>
    );
};

export default Restoration;