import React from 'react'
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import http from "../../http_common";
import { LoadUser } from '../../actions/users';
import { Link } from 'react-router-dom';


const ListUsers = () => {
    const dispatch = useDispatch();
    const { list } = useSelector(state => state.user);

    useEffect(() => {
        dispatch(LoadUser());
        console.log("UseEffect done:");

    }, []);

    return (
        <>
            <h2>Список користувачів</h2>
            <table className="table">
                <thead className="table table-light">
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">Image</th>
                        <th scope="col">Name</th>
                    </tr>
                </thead>
                <tbody>
                    {list && list.map((item) =>
                        <tr key={item.email}>
                            <td>{item.id}</td>
                            <td>
                                <img src={http.defaults.baseURL + item.photo}
                                    alt="user photo"
                                    width="150"
                                />
                            </td>
                            <td>{item.email}</td>
                            <td>
                               {/* <Link to={`/edit/${item.id}`}>Edit</Link> / 
                                <Link to={`/delete/${item.id}`}>Delete</Link>  */}
                            </td>
                        </tr>)}
                </tbody>
            </table>
        </>
    );
}
export default ListUsers;
