import React from 'react';

const LoginPage: React.FC = () => {

    const login = (e: React.ChangeEvent<HTMLFormElement>) => {
        e.preventDefault();
        
    }

    const registerUser = () => {
        
    }
    
    return (
        <div className="min-h-screen flex items-center justify-center bg-orange-300">
            <form 
                onSubmit={login}
                className="bg-white p-8 rounded-lg shadow-lg w-full max-w-sm"
            >
                <h2 className="text-2xl font-bold mb-6 text-center text-orange-600">Login</h2>
                <div className="mb-4">
                    <label 
                        htmlFor="studentID"
                        className="block text-orange-700 font-semibold mb-2"
                    >
                        Student ID: 
                    </label>
                    <input 
                        type="text" 
                        id="studentID" 
                        name="studentID" 
                        required
                        className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-orange-500"
                    />
                </div>
                
                <div className="mb-6">
                    <label 
                        htmlFor="studentID"
                        className="block text-orange-700 font-semibold mb-2"
                    >
                        Password:
                    </label>
                    <input 
                        type="password" 
                        id="password" 
                        name="password" 
                        required
                        className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-orange-500"
                    />
                </div>
                
                <div className="mb-4">
                    <button 
                        type="submit" 
                        className="w-full bg-orange-500 text-white py-2 rounded-lg hover:bg-orange-600 transition-colors duration-300" 
                        value="login"
                    >
                        Login
                    </button>
                </div>

                <div>
                    <button 
                        type="button" 
                        value="signup" 
                        onClick={registerUser}
                        className="w-full bg-white text-orange-500 border border-orange-500 py-2 rounded-lg hover:bg-orange-50 transition-colors duration-300"
                    >
                        Register
                    </button>
                </div>
            </form>
        </div>
    )
}

export default LoginPage;
