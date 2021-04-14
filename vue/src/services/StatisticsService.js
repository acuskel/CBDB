import axios from 'axios';

const path = '/statistics';

export default {
    getStatistics() {
        return axios.get(path)
    },
}