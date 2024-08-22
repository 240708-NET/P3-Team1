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
  register: (user: User) => Promise<void>;
  logout: () => void;
}

interface UserProviderProps {
  children: ReactNode;
};

export const UserContext = createContext<UserContextProps | undefined>(undefined);

const UserProvider: React.FC<UserProviderProps> = ({ children }) => {
  const [user, setUser] = useState(() => {
    const localData = localStorage.getItem('userData');
    return localData ? JSON.parse(localData) : undefined;
  });

  const login = async ( user: User ) => {
    await axios.post(`${API_BASE}/Student/login`, user).then((res: AxiosResponse) => {
      setUser(res.data);
      localStorage.setItem("userData", JSON.stringify(user));
    }).catch((error: AxiosError) => {
      throw error;
    })
    console.log(user);
  }

  const register = async ( user: User ) => {
    await axios.post(`${API_BASE}/Student/register`, user).then((res: AxiosResponse) => {
      setUser(res.data);
      localStorage.setItem("userData", JSON.stringify(user));
    }).catch((error: AxiosError) => {
      throw error;
    })
  }

  const logout = () => {
    setUser(undefined);
    localStorage.removeItem("userData");
  }

  return (
    <UserContext.Provider value={{ user: user, login, register, logout }}> 
      { children } 
    </UserContext.Provider>
  );
}

export const useUser = () => useContext(UserContext);

export default UserProvider;