import React, { useEffect, useState } from 'react';
import './styles/App.css';
import CreateNoteForm from './components/CreateNoteForm';
import Note from './components/Note';
import { fetchNotes, createNote, deleteNote} from './services/notes';
import Filters from './components/Filters';
import { Card } from '@chakra-ui/react';

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
    <div className='min-h-screen bg-gradient-to-b from-sky-100 grid place-items-center p-1'>
      <Card className='border-2 border-gray-300 rounded-lg shadow-xl w-full max-w-6xl'>
      <section className='bg-slate-50 p-8 flex flex-row justify-start items-start gap-12'> 
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
    </Card>
    </div>
  );
}
export default App;
