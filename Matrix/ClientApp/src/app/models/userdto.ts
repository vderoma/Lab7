import { PhotoDto } from "./photodto";

export interface UserDto {
  id: number;
  userName: string;
  gender: string;
  name: string;
  created: Date;
  lastActive: Date;
  city: string;
  age: number;
  photoUrl: string;
  introduction?: string;
  lookingFor?: string;
  interests?: string;
  photos?: Array<PhotoDto>;

}
