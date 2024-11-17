import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Single.css';

const Restorer = () => {
    const {id} = useParams();
    const [restorer, setRestorer] = useState([]);
    const [exp, setExp] = useState([]);
    const url = 'http://localhost:5214/api/restorer/';
    
    useEffect(() => {
        fetch(`${url}${id}`, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setRestorer(data));
    });

    const handleDelete = async () => {
        await fetch(`${url}${id}`, {method: 'DELETE', headers: {'Content-Type': 'application/json'}});
        window.location.href = "/restorers"
    };

    const handleUpdate = async (e) => {
        e.preventDefault();
        const id = restorer.id;
        let experience = Number(restorer.experience);
        if(exp.length !== 0){
            experience = Number(exp);
        }
        const updateRestorer = {
            id,
            experience
        }
        console.log(updateRestorer)
        await fetch(url, {method: 'PUT', headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(updateRestorer)});
        setExp('');
    }

    return (
        <div class='container'>
            <a href={`../person/${restorer.id}`}>Restorer ID:{restorer.id}</a><br/>
            Experience: {restorer.experience}<br/><br/>
            <button class='delete-button' onClick={handleDelete}>Delete</button><br/>
            <form onSubmit={handleUpdate}>
                <label for='exp'>Experience:</label>
                <input type="number" id='exp' name='exp' value={exp} onChange={(e) => setExp(e.target.value)}/><br/>
                <button type="submit">Update</button><br/>
            </form>
        </div>
    );
};

export default Restorer;