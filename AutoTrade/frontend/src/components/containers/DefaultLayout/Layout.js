import React from 'react';
import FlashMessageToast from '../../Flash/FlashMessageToast';


import Header from '../../header';


export default props => (
    <>
      <Header />
      <div className="container">
        {props.children}
      </div>
    <FlashMessageToast />
   
    </>
  );
