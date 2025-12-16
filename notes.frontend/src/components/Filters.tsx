
import { Input } from '@chakra-ui/react';
import { Select } from '@chakra-ui/react';

export default function Filters() {
  return (
    <div className='flex flex-col gap-5'>
        <Input placeholder='Поиск'/>
        <Select placeholder="Сортировка">
            <option>Сначала новые</option>
            <option>Сначала старые</option>
        </Select>
    </div>
    );
}