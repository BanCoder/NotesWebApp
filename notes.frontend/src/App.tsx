import React, { useEffect, useState } from 'react';
import './App.css';
import CreateNoteForm from './components/CreateNoteForm';
import Note from './components/Note';
import { fetchNotes, createNote, deleteNote} from './services/notes';
import Filters from './components/Filters';

interface NoteType {
  id: number;
  title: string; 
  description: string
  created: string; 
}
interface FilterType {
  search: string;
  sortItem: string;
  sortOrder: 'desc' | 'asc';
}
function App() {
  const [notes, setNotes] = useState<NoteType[]>([]);
  const [filter, setFilter] = useState<FilterType>({
    search: "", 
    sortItem: "date", 
    sortOrder: "desc"
  }); 
  useEffect(() => {
    const fetchData = async () => {
      let notes =await fetchNotes(filter); 
      setNotes(notes); 
    }
    fetchData(); 
  }, [filter]);
  const onCreate = async (note: { title: string, description: string }) => {
    await createNote(note);
    const notes = await fetchNotes(filter);
    setNotes(notes || []);
  };
  const onDelete = async (id: number) => {
    await deleteNote(id); 
    const notes = await fetchNotes(filter); 
    setNotes(notes || []);
  }
  return (
    <section className='p-8 flex flex-row justify-start items-start gap-12'> 
      <div className="flex flex-col w-1/3 gap-10">
        <CreateNoteForm onCreate={onCreate}/>
        <Filters filter={filter} setFilter ={setFilter} />
      </div>
      <ul className='flex flex-col gap-5 w-1/2 list-none'>
          {notes.map((n) => ( 
          <li key={n.id}>
            <Note 
              title={n.title}
              description={n.description}
              createdAt={n.created}
              onDelete={()=> onDelete(n.id)}
            />
          </li>
        ))}
        </ul>
    </section>
  );
}
export default App;
