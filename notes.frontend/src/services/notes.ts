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
export const createNote = async (note: { text: string }) => {
    try{
        var response = await axios.post("http://localhost:5143/note", note)
        return response.status; 
    }
    catch(e){
        console.log(e); 
    }
}