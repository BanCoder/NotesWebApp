import axios from "axios"

interface FilterType {
  search?: string;
  sortOrder?: string;
  sortItem?: string;
}

export const fetchNotes = async (filter?: FilterType) => {
    try{
        var response = await axios.get("http://localhost:5143/note", {
        params: {
            search: filter?.search, 
            sortItem: filter?.sortItem, 
            sortOrder: filter?.sortOrder
        }, 
    });
        return response.data; 
    }
    catch(e){
        console.log(e); 
    }
}
export const createNote = async (note: { title: string, description: string}) => {
    try{
        var response = await axios.post("http://localhost:5143/note", null,
            {
                params: {
                    title: note.title, 
                    description: note.description
                }
            }
        ); 
        return response.status; 
    }
    catch(e){
        console.log(e); 
    }
}
export const deleteNote = async (id: number) => {
    try{
        var response = await axios.delete(`http://localhost:5143/note/${id}`)
        return response.status; 
    }
    catch(e){
        console.log(e); 
    }
}