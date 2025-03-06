import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 10, // Virtual Users (concurrent users)
    duration: '30s', // Test duration
};

export default function () {
    let res = http.get('https://your-api-url.com'); // Replace with your API endpoint
    check(res, {
        'is status 200': (r) => r.status === 200, // Check if response status is 200
    });
    sleep(1); // Sleep for 1 second between requests
}