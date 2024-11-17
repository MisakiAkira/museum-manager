import React from 'react';
import MyRouter from './components/Router';
import './App.css'

const App = () => {
  return (
    <div>
      <div className='header'>
      <a href="/people">People</a><br/>
      <a href='/authors'>Authors</a><br/>
      <a href="/paintings">Paintings</a><br/>
      <a href="/restorers">Restorers</a><br/>
      <a href='/restorations'>Restorations</a>
      </div>
      <MyRouter/>
    </div>
  );
};

export default App;