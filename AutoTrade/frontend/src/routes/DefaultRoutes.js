import React from 'react';
import Header from '../components/header';

const Home = React.lazy(() => import("../components/home"));
const Dialog = React.lazy(() => import("../components/dialog"));
const Login = React.lazy(() => import("../components/auth/Login"));
const Register = React.lazy(() => import("../components/auth/Register"));
const ListUsers = React.lazy(() => import("../components/users"));


const defaultRoutes = [

    { path: '/', exact: true, name: 'Головна', component: Home  },
    { path: '/dialog', exact: true, name: 'Діалог', component: Dialog  },
    { path: '/users', exact: true, name: 'Користувачі', component: ListUsers  },
    { path: '/login', exact: true, name: 'Вхід', component: Login  },
    { path: '/register', exact: true, name: 'Реєстрація', component: Register  }
];
export default defaultRoutes;