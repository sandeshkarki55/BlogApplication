import axios from 'axios';

export class BaseAxiosService {
    constructor() {
        let token = localStorage.getItem('token');
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    }
}