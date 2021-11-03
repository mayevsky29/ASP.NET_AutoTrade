import React from 'react';
import Header from '../components/header';

const Home = React.lazy(() => import("../components/home"));
const Login = React.lazy(() => import("../components/auth/Login"));
const Register = React.lazy(() => import("../components/auth/Register"));


const defaultRoutes = [

    { path: '/home', exact: true, name: 'Головна', component: Home  },
    { path: '/login', exact: true, name: 'Вхід', component: Login  },
    { path: '/register', exact: true, name: 'Реєстрація', component: Register  }
];
export default defaultRoutes;