
import { FilterProps, Input } from '@chakra-ui/react';
import { Select } from '@chakra-ui/react';
interface FilterType {
    search: string;  
    sortItem: string;
    sortOrder: 'desc' | 'asc';
}
interface FiltersProps {
  filter: FilterType;
  setFilter: (filter: FilterType) => void;
}
export default function Filters({ filter, setFilter }: FiltersProps) {
  return (
    <div className='flex flex-col gap-5'>
        <Input placeholder='Поиск' onChange={(e) => setFilter({...filter, search: e.target.value})}/>
        <Select onChange={(e) => setFilter({...filter, sortOrder: e.target.value as 'asc' | 'desc'})}>
            <option value={"desc"}>Сначала новые</option>
            <option value={"asc"}>Сначала старые</option>
        </Select>
    </div>
    );
}