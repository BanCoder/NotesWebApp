import { Card, CardHeader, Heading, Divider, CardBody, Text, CardFooter } from '@chakra-ui/react';
import moment from 'moment';
interface NoteProps{
    title: string; 
    description: string;
    createAt: string;
}
export default function Note({title, description, createAt}: NoteProps) {
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
            <CardFooter>{moment(createAt).format("DD/MM/YYYY h:mm:ss")}</CardFooter>
        </Card>
    );
}