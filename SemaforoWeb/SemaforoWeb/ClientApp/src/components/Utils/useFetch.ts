import { useState } from 'react'
import { dataItem } from '../../types'

const useFetch = (APIurl: string, httpRequest?: string) => {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [data, setData] = useState<any>(null)

  const triggerFetch = async (
    item?: string,
    payload?: FormData,
    tHttpRequest?: string,
    tAPIurl?: string,
  ) => {
    try {
      const http = tHttpRequest ? tHttpRequest : httpRequest
      let url: string = tAPIurl ? tAPIurl : APIurl
      if (item && (http === 'GET' || http === 'PUT' || http === 'DELETE')) {
        url += item
      }

      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const options: any = {
        method: http,
        headers: { 'Content-Type': 'application/json' },
      }
      if (http === 'POST' || (item && http === 'PUT')) {
        options.body = payload ? payload : ''
        options.headers = { enctype: 'multipart/form-data' }
      }

      const fetchData = async () => {
        const data = await fetch(url, options)
        const json = await data.json()
        setData(json)
      }
      fetchData()
    } catch (error) {
      console.log(error)
    }
  }

  return [data, triggerFetch]
}

export default useFetch
