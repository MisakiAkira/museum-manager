import React, { useState } from 'react';
import './List.css';

const Restorations = () => {
    const [restorations, setRestorations] = useState([]);
    const [restorerId, setRestorerId] = useState([]);
    const [paintingId, setPaintingId] = useState([]);
    const [cost, setCost] = useState([]);
    const [startDate, setStartDate] = useState([]);
    const [endDate, setEndDate] = useState([]);
    const url = 'http://localhost:5214/api/';

    const getRestorations = () => {
        fetch(`${url}restoration`, {method: 'GET'})
        .then(response=>response.json())
        .then(data=>setRestorations(data));
    };

    const handleDeleet = async (restorerId, paintingId) => {
        const response = await fetch(`${url}restoration/${restorerId}/${paintingId}`, {method: 'DELETE'});
        if(response.ok){
            window.location.reload();
        }
    }

    const addRestoration = async () => {
        const newRestoration = {
            restorerId,
            paintingId,
            cost,
            startDate,
            endDate
        };
        console.log(JSON.stringify(newRestoration))
        await fetch(`${url}restoration`, {method: 'POST',headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(newRestoration)});
        setRestorerId('');
        setPaintingId('');
        setCost('');
        setStartDate('');
        setEndDate('');
    }

    return (
        <div class="container">
            <form onSubmit={addRestoration}>
                <label for="id1">Restorer ID:</label>
                <input type="number" id="id1" name="id1" value={restorerId} onChange={(e) => setRestorerId(e.target.value)} required/><br/>
                <label for="id2">Painting ID:</label>
                <input type="number" id="id2" name="id2" value={paintingId} onChange={(e) => setPaintingId(e.target.value)} required/><br/>
                <label for="cost">Cost:</label>
                <input type="number" id="cost" name="cost" value={cost} onChange={(e) => setCost(e.target.value)} required/><br/>
                <label for="sdate">Start date:</label>
                <input type="date" id="sdate" name="sdate" value={startDate} onChange={(e) => setStartDate(e.target.value)} required/><br/>
                <label for="edate">End date:</label>
                <input type="date" id="edate" name="edate" value={endDate} onChange={(e) => setEndDate(e.target.value)} required/><br/>
                <button type='submit'>Add</button>
            </form><br/>
            <button class="button-primary" onClick={getRestorations}>Get Restorations</button><br/><br/>
            <ul>
            {restorations.map(restoration => (
                <li key={restoration.restorerId}>
                    <a href={`restoration/${restoration.restorerId}/${restoration.paintingId}`}>
                        Restorer id: {restoration.restorerId}<br/>
                        Painting id: {restoration.paintingId}
                    </a>
                    <button class="delete-button" onClick={() => handleDeleet(restoration.restorerId, restoration.paintingId)}>Delete</button>
                </li>
            ))}
            </ul>
        </div>
    );
};

export default Restorations;