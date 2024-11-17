import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Single.css';

const Painting = () => {
    const {id} = useParams();
    const [painting, setPaintings] = useState([]);
    const [auId, setAuId] = useState([]);
    const [pName, setName] = useState([]);
    const [pDate, setDate] = useState([]);
    const [desc, setDesc] = useState([]);
    const urlPainting = 'http://localhost:5214/api/painting/';
    
    useEffect(() => {
        fetch(`${urlPainting}${id}`, {method: 'GET', headers: {'Content-Type': 'application/json'}})
        .then(response => response.json())
        .then(data => setPaintings(data));
    });

    const handleDelete = async () => {
        await fetch(`${urlPainting}${id}`, {method: 'DELETE', headers: {'Content-Type': 'application/json'}});
        window.location.href = "/paintings"
    };

    const handleUpdate = async (e) => {
        const id = painting.id;
        let authorId = painting.authorId;
        let name = painting.name;
        let paintingDate = painting.paintingDate;
        let description = painting.description;
        if(auId.length !== 0){
            authorId = auId;
        }
        if(String(pName).trim().length !== 0){
            name = pName;
        }
        if(pDate.length !== 0){
            paintingDate = pDate;
        }
        if(String(desc).trim().length !== 0){
            description = desc;
        }
        const updateAuthor = {
            id,
            authorId,
            name,
            paintingDate,
            description
        }
        console.log(updateAuthor)
        await fetch(urlPainting, {method: 'PUT', headers:{
            'Content-Type': 'application/json'
        }, body: JSON.stringify(updateAuthor)});
        setAuId('');
        setName('');
        setDate('');
        setDesc('');
    }

    return (
        <div class="container">
            Painting ID: {painting.id}<br/>
            <a href={`../author/${painting.authorId}`}>Author ID:{painting.authorId}</a><br/>
            Name: {painting.name}<br/>
            Painting date: {painting.paintingDate}<br/>
            Description: {painting.description}<br/><br/>
            <button class="delete-button" onClick={handleDelete}>Delete</button><br/>
            <form onSubmit={handleUpdate}>
                <label for="id">Author ID:</label>
                <input type="number" id="id" name="id" value={auId} onChange={(e) => setAuId(e.target.value)}/><br/>
                <label for="name">Name:</label>
                <input type='text' id="name" name="name" vale={pName} maxLength={50} onChange={(e) => setName(e.target.value)}/><br/>
                <label for="date">Painting date:</label>
                <input type='date' id="date" name="date" vale={pDate} onChange={(e) => setDate(e.target.value)}/><br/>
                <label for="desc">Description:</label>
                <input type='text' id="desc" name="desc" value={desc} maxLength={255} onChange={(e) => setDesc(e.target.value)}/><br/>
                <button type="submit">Update</button><br/>
            </form>
        </div>
    );
};

export default Painting;