import os
os.environ["HF_HUB_DISABLE_XET"] = "1"
os.environ['HF_ENDPOINT'] = 'https://hf-mirror.com' # if don't need mirror proxy, comment this line
# os.environ['HF_HUB_CACHE'] = 'D:\ai\huggingface\hub' # if use custom folder, uncommont this line

from transformers import AutoModelForCTC

def get_model(model_name: str):  

    model_ctc = AutoModelForCTC.from_pretrained(model_name).to('cpu')

    return model_ctc