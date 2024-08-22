import React, { createContext, useState, ReactNode, useContext } from "react";
import axios, { AxiosError, AxiosResponse } from "axios";

const API_BASE = import.meta.env.VITE_API_BASE;

interface User {
  id: number;
  firstName: string;
  lastName: string;
  password: string;
}

interface UserContextProps {
  user: User | undefined;
  login: (user: User) => Promise<void>;
}

interface UserProviderProps {
  children: ReactNode;
};

export const UserContext = createContext<UserContextProps | undefined>(undefined);

const UserProvider: React.FC<UserProviderProps> = ({ children }) => {
  const [ user, setUser ] = useState<User>();

  const login = async ( user: User ) => {
    await axios.post(`${API_BASE}/Student/login`, user).then((res: AxiosResponse) =>{
      console.log(res);
    }).catch((error: AxiosError) => {
      throw error;
    })
  }

  return (
    <UserContext.Provider value={{ user: user, login }}> 
      { children } 
    </UserContext.Provider>
  );
}

export const useUser = () => useContext(UserContext);

export default UserProvider;