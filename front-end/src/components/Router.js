import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Person from './routes/Person'
import People from './routes/PersonList';
import Authors from './routes/AuthorList';
import Author from './routes/Author';
import Paintings from './routes/PaintingList';
import Painting from './routes/Painting';
import Restorers from './routes/RestorerList';
import Restorer from './routes/Restorer';
import Restorations from './routes/RestorationList';
import Restoration from './routes/Restoration';

const MyRouter = () => {
    return (
        <Router>
            <Routes>
                <Route path="/person/:id" element={<Person/>}/>
                <Route path="/people" element={<People/>}/>
                <Route path="/authors" element={<Authors/>}/>
                <Route path="/author/:id" element={<Author/>}/>
                <Route path="/paintings" element={<Paintings/>}/>
                <Route path="/painting/:id" element={<Painting/>}/>
                <Route path="/restorers" element={<Restorers/>}/>
                <Route path="/restorer/:id" element={<Restorer/>}/>
                <Route path="/restorations" element={<Restorations/>}/>
                <Route path="/restoration/:restorerId/:paintingId" element={<Restoration/>}/>
            </Routes>
        </Router>
    );
};

export default MyRouter;