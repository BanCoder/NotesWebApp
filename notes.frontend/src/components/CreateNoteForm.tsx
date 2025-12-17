import { Button, Input, Textarea } from '@chakra-ui/react';
import { useState } from 'react';

interface NoteFormData {
  title: string;
  description: string;
}

interface CreateNoteFormProps {
  onCreate: (note: { text: string }) => void;
}

export default function CreateNoteForm({ onCreate }: CreateNoteFormProps) {
  const [note, setNote] = useState<NoteFormData>({ title: '', description: '' });

  const onSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const noteForBackend = { text: `${note.title}: ${note.description}` };
    onCreate(noteForBackend);
    setNote({ title: '', description: '' });
  };

  return (
    <form onSubmit={onSubmit} className='w-full flex flex-col gap-3'>
      <h3 className='font-bold text-xl'>Создание заметки</h3>
      <Input
        placeholder='Название'
        value={note.title}
        onChange={(e) => setNote({ ...note, title: e.target.value })}
      />
      <Textarea
        placeholder='Описание'
        value={note.description}
        onChange={(e) => setNote({ ...note, description: e.target.value })}
      />
      <Button type='submit' colorScheme='teal'>Создать</Button>
    </form>
  );
}