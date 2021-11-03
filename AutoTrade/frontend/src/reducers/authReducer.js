import { LOGIN, REGISTER, REGISTER_BEGIN, 
    REGISTER_FAILED, LOGOUT, SET_ROLE } from "../constants/actionTypes";

const initialState ={
    isAuth: false,
    user: {},
    loading: false
}

const authReducer = (state = initialState, action) => {
    const {type, payload} = action;
    switch(type) {
        case REGISTER_BEGIN: {
            return {
                ...state,
                loading: true
            }
        }
        case REGISTER_FAILED: {
            return {
                ...state,
                loading: false

            }
        }
        case REGISTER: {
            return {
                isAuth: false,
                loading: false
            };
        }
        case LOGIN: {
            return {
                isAuth: true,
                user: payload,
                loading: false
            };
        } 
        case LOGOUT: {
            return { 
                isAuth: false
            }
        }
        case SET_ROLE: {
            return { 
                ...state,
                role: action.payload
            }
        }
        default: {
            return state;
        }
    }
    

}

export default authReducer;