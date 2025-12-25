import { Card, CardHeader, Heading, Divider, CardBody, Text, CardFooter, Button, Flex } from '@chakra-ui/react';
import moment from 'moment';
interface NoteProps{
    title: string; 
    description: string;
    createdAt: string;
    onDelete?: () => void
}
export default function Note({title, description, createdAt, onDelete}: NoteProps) {
  return (
        <Card variant={"filled"}>
            <CardHeader>
                <Heading size={"md"}>{title}</Heading>
            </CardHeader>
            <Divider borderColor={"gray"}/>
            <CardBody>
                <Text>{description}</Text>
            </CardBody>
            <Divider borderColor={"gray"}/>
            <CardFooter>{moment(createdAt).format("DD/MM/YYYY h:mm:ss")}</CardFooter>
            <Flex justify={'space-between'}>
                <Button type='submit' colorScheme='blue' margin={3} width={'full'} onClick={onDelete}>Удалить</Button>
            </Flex>
        </Card>
    );
}