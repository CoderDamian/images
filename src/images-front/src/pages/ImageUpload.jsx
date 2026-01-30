import { useState } from "react";
import Nombre from '../components/nombre';
import ImageFile from '../components/imageFile'

const ImageUpload = () => {
  const [imageName, setImageName] = useState();
  const [imageFile, setImageFile] = useState(null);

  function handleOnNameChange(e){
    setImageName(e.target.value);
  }

  function handleOnImageChange(e){
    const selectedFile = e.target.files[0];
    setImageFile(selectedFile ?? null);
  }

  async function uploadData(){
    if (imageName.length == 0)
      throw new Error('Digite un nombre para el archivo');
    
    if (imageFile == null)
      throw new Error('Debe escoger un archivo');
    
    const formData = new FormData();
    formData.append('image', imageFile);
    formData.append('nombreArchivo', imageName);
    formData.append('tipoContenido', 'x');
    
    try {
      const response = await fetch('https://localhost:7038/api/images', {
        method: 'post',
        body: formData
      });

      if (!response.ok)
        throw response;

      alert("Image uploaded successfully");

    } catch (error) {
      if (error instanceof Response) {
            // It's an HTTP error response
            const errorBody = await error.text();
            console.error(`HTTP error, status ${error.status}:`, errorBody);
        }
    }
  }

  return<>
    <Nombre eventHandler = {handleOnNameChange}/>
    <ImageFile eventHandler = {handleOnImageChange}/>
    <br></br>
    <button onClick={uploadData}>Guardar el archivo</button>
  </>
}

export default ImageUpload;