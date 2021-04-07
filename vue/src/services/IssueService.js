import axios from 'axios';

const path = '/issue';

export default {
    getIssues(collectionId) {
        return axios.get(path + 'collection/' + collectionId)
    }
}