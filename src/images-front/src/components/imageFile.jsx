const ImageFile = ({eventHandler}) => {
    return<>
        <div>
            <h2>Adjuntar archivo de imagen</h2>
        </div>
        <div>
            <input
                type="file"
                accept="image/*"
                onChange={eventHandler}
            ></input>
        </div>
    </>
}

export default ImageFile;