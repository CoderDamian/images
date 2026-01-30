import { useState } from "react";

const Nombre = ({ eventHandler }) => {
    return <>
        <div>
            <h2>Nombre del archivo</h2>
            <input
                type="text"
                onChange={eventHandler}>
            </input>
        </div>
    </>
}

export default Nombre;